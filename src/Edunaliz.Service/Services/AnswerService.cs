using AutoMapper;
using Edunaliz.DataAccess.IRepositories;
using Edunaliz.Domain.Entities;
using Edunaliz.Service.DTOs.Answers;
using Edunaliz.Service.Exceptions;
using Edunaliz.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Edunaliz.Service.Services;

public class AnswerService : IAnswerService
{
    private readonly IRepository<Answer> repository;
    private readonly IMapper mapper;
    public AnswerService(IRepository<Answer> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async ValueTask<AnswerResultDto> AddAsync(AnswerCreationDto dto)
    {
        var answer = await repository.GetAsync(x => x.Question.Id.Equals(dto.QuestionId));
        if (answer is not null)
            throw new AlreadyExistException("Already exist!");

        var mapAnswer = mapper.Map<Answer>(dto);
        await repository.AddAsync(mapAnswer);
        await repository.SaveAsync();

        var res = mapper.Map<AnswerResultDto>(mapAnswer);
        return res;
    }

    public async ValueTask<AnswerResultDto> ModifyAsync(AnswerUpdateDto dto)
    {
        var answer = await repository.GetAsync(x => x.Id.Equals(dto.Id))
            ?? throw new NotFoundException("Not found!");

        var mapAnswer = mapper.Map(dto, answer);
        repository.Update(mapAnswer);
        await repository.SaveAsync();

        var res = mapper.Map<AnswerResultDto>(mapAnswer);
        return res;
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var answer = await repository.GetAsync(x => x.Id.Equals(id))
            ?? throw new NotFoundException("Not found!");

        repository.Delete(answer);
        await repository.SaveAsync();

        return true;
    }

    public async ValueTask<AnswerResultDto> RetrieveByIdAsync(long id)
    {
        var answer = await repository.GetAsync(x => x.Id.Equals(id))
            ?? throw new NotFoundException("Not found!");

        var res = mapper.Map<AnswerResultDto>(answer);
        return res;
    }

    public async ValueTask<IEnumerable<AnswerResultDto>> RetrieveAllAsync()
    {
        var answer = await repository.GetAll().ToListAsync();
        var res = mapper.Map<IEnumerable<AnswerResultDto>>(answer);
        return res;
    }
}
