using Cms.Entities.Concrete.Dtos.ArticleDtos;
using Cms.Entities.Concrete.Dtos.CommentDtos;
using Cms.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Abstract
{
  public interface ICommentService
  {
		Task<IDataResult<CommentDto>> Get(int commentId);
		Task<IDataResult<CommentListDto>> GetAll();
		Task<IDataResult<CommentListDto>> GetAllByNonDeleted();
		Task<IDataResult<CommentListDto>> GetAllByNonDeletedAndActive();
		Task<IDataResult<CommentListDto>> GetAllByArticle(int articleId);
		Task<IDataResult<CommentListDto>> GetAllByDoctor(int doctorId);
		Task<IResult> Add(CommentDto commentAddDto, int createdById);
		Task<IResult> Update(CommentDto commentUpdateDto, int modifiedById);
		Task<IResult> Delete(int articleId, int modifiedById);
		Task<IResult> HardDelete(int commentId);
	}
}
