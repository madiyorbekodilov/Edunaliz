using Edunaliz.Service.DTOs.Answers;

namespace Edunaliz.Service.Interfaces;

public interface IAnswerService
{
    ValueTask<AnswerResultDto> AddAsync(AnswerCreationDto dto);
    ValueTask<AnswerResultDto> ModifyAsync(AnswerUpdateDto dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<AnswerResultDto> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<AnswerResultDto>> RetrieveAllAsync();
}
