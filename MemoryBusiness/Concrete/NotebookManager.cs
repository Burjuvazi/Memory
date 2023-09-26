using AutoMapper;
using FluentValidation.Results;
using Memory.Business.Abstract;
using Memory.Business.ValidationRules.FluentValidation;
using Memory.DataAccess.Abstract;
using Memory.Entities.Concrete;
using Memory.Entities.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Business.Concrete
{
    public class NotebookManager : INotebookService
    {
        NotebookValidator rules = new NotebookValidator();
        private readonly INoteBookDal _notebookDal;
        private readonly IMapper _mapper;

        public NotebookManager(INoteBookDal noteBookDal, IMapper mapper)
        {
            _notebookDal = noteBookDal;
            _mapper = mapper;
        }
        private ValidationResult Validate(Notebook notebook)
        {
            return rules.Validate(notebook);
        }
        public Notebook NotebookDtoConvert(NotebookDto notebookDto)
        {
            return _mapper.Map<Notebook>(notebookDto);
        }
        public async Task<bool> AddNotebookAsync(NotebookDto notebookDto)
        {
            Notebook notebook = NotebookDtoConvert(notebookDto);
            ValidationResult result = Validate(notebook);
            if (result.IsValid)
            {
                int response = await _notebookDal.AddAsync(notebook);
                return response > 0;
            }
            return false;
        }

        public async Task<bool> DeleteNotebookAsync(NotebookDto notebookDto)
        {
            Notebook notebook = NotebookDtoConvert(notebookDto);
            int response = await _notebookDal.DeleteAsync(notebook);
            return response > 0;
        }

        public async Task<List<NotebookDto>> GetAllNoteBookAsync()
        {
            List<Notebook> notebooks = await _notebookDal.GetAllAsync();
            List<NotebookDto> notebookDtos = new List<NotebookDto>();
            foreach (Notebook item in notebooks)
            {
                NotebookDto notebookDto = _mapper.Map<NotebookDto>(item);
                notebookDtos.Add(notebookDto);
            }
            return notebookDtos;
           
        }
        public async Task<List<NotebookDto>> GetAllCityByRuleAsync(string notebookName)
        {
            List<Notebook> notebooks = await _notebookDal.GetAllAsync(x => x.Title.Contains(notebookName));
            List<NotebookDto> notebookDtos = new List<NotebookDto>();
            foreach (Notebook item in notebooks)
            {
                NotebookDto notebookDto = _mapper.Map<NotebookDto>(item);
                notebookDtos.Add(notebookDto);
            }
            return notebookDtos;
        }

        public async Task<NotebookDto> GetNoteBookByIdAsync(int id)
        {
            Notebook notebook = await _notebookDal.GetAsync(x => x.Id == id);
            return _mapper.Map<NotebookDto>(notebook);
        }

        public async Task<bool> UpdateNotebookAsync(NotebookDto notebookDto)
        {
            Notebook notebook = NotebookDtoConvert(notebookDto);
            ValidationResult result = Validate(notebook);
            if (result.IsValid)
            {
                int response = await _notebookDal.UpdateAsync(notebook);
                return (response > 0);
            }
            return false;
            
        }


      
    }
}
