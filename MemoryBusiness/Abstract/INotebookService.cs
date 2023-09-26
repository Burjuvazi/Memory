using Memory.DataAccess.Concrete.EntityFrameWork;
using Memory.Entities.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Business.Abstract
{
    public interface INotebookService
    {
        Task<bool> AddNotebookAsync(NotebookDto noteBookDto);
        Task<bool> UpdateNotebookAsync(NotebookDto noteBookDto);
        Task<bool> DeleteNotebookAsync(NotebookDto notebookDto);
        Task<NotebookDto> GetNoteBookByIdAsync(int id);
        Task<List<NotebookDto>> GetAllNoteBookAsync();
        Task<List<NotebookDto>> GetAllCityByRuleAsync(string notebookName);
    }
}
