using AutoMapper;
using Cms.Data.EntityFramework.Contexts;
using Cms.Entities.Concrete.Dtos.ArticleDtos;
using Cms.Entities.Concrete;
using Cms.Entities.Concrete.Dtos.CommentDtos;
using Cms.Services.Abstract;
using Cms.Shared.Utilities.Results.Abstract;
using Cms.Shared.Utilities.Results.Complex_Types;
using Cms.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cms.Services.Concrete
{
	public class CommentManager : ICommentService
	{
		private readonly CmsContext _context;
		private readonly IMapper _mapper;

		public CommentManager(CmsContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<IResult> Add(CommentAddDto commentAddDto, int createdById)
		{
			var comment = _mapper.Map<Comment>(commentAddDto);
			comment.CreatedById = createdById;
			comment.ModifiedById = createdById;
			comment.UserId = createdById;
			await _context.Comments.AddAsync(comment);
			await _context.SaveChangesAsync();
			return new Result(ResultStatus.Success, "Comment saved successfully.");
		}

		public async Task<IResult> Delete(int commentId, int modifiedById)
		{
			var comment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == commentId);
			if (comment != null)
			{
				comment.IsDeleted = true;
				comment.ModifiedById = modifiedById;
				comment.ModifiedDate = DateTime.Now;
				_context.Comments.Update(comment);
				await _context.SaveChangesAsync();
				return new Result(ResultStatus.Success, "Comment deleted successfully.");
			}
			return new Result(ResultStatus.Error, "No comment found.");
		}

		public async Task<IDataResult<CommentDto>> Get(int commentId)
		{
			var comment = await _context.Comments
																	.Include(c => c.Article)
																	.Include(c => c.User)
										.SingleOrDefaultAsync(c => c.Id == commentId);

			if (comment != null)
			{
				return new DataResult<CommentDto>(ResultStatus.Success, new CommentDto
				{
					Comment = comment,
					ResultStatus = ResultStatus.Success,
				});
			}
			return new DataResult<CommentDto>(ResultStatus.Error, "No comemnt found", null);
		}

		public async Task<IDataResult<CommentListDto>> GetAll()
		{
			var comments = await _context.Comments
												 .Include(c => c.Article)
												 .Include(c => c.User).ToListAsync();
			if (comments.Any())
			{
				return new DataResult<CommentListDto>(ResultStatus.Success, new CommentListDto
				{
					Comments = comments,
					ResultStatus = ResultStatus.Success,
				});
			}
			return new DataResult<CommentListDto>(ResultStatus.Error, "No comments found", null);
		}

		public async Task<IDataResult<CommentListDto>> GetAllByArticle(int articleId)
		{
			var result = await _context.Articles.AnyAsync(c => c.Id == articleId);

			if (result)
			{
				var comments = await _context.Comments
																			.Include(a => a.User)
																			.Include(a => a.Article)
																			.Where(a => a.ArticleId == articleId && !a.IsDeleted && a.IsActive)
																			.ToListAsync();
				if (comments.Any())
				{
					return new DataResult<CommentListDto>(ResultStatus.Success, new CommentListDto
					{
						Comments = comments,
						ResultStatus = ResultStatus.Success,
					});
				}
				return new DataResult<CommentListDto>(ResultStatus.Error, "No comments found", null);
			}
			return new DataResult<CommentListDto>(ResultStatus.Error, "No article found", null);
		}

		public async Task<IDataResult<CommentListDto>> GetAllByDoctor(int doctorId)
		{
			var result = await _context.Comments.AnyAsync(c => c.Id == doctorId);

			if (result)
			{
				var comments = await _context.Comments
																			.Include(c => c.User)
																			.Include(c => c.Article)
																			.Include(c => c.Doctor)
																			.Where(c => c.DoctorId == doctorId && !c.IsDeleted && c.IsActive)
																			.ToListAsync();
				if (comments.Any())
				{
					return new DataResult<CommentListDto>(ResultStatus.Success, new CommentListDto
					{
						Comments = comments,
						ResultStatus = ResultStatus.Success,
					});
				}
				return new DataResult<CommentListDto>(ResultStatus.Error, "No comments found ", null);
			}
			return new DataResult<CommentListDto>(ResultStatus.Error, "No articles found for the doctor", null);
		}

		public async Task<IDataResult<CommentListDto>> GetAllByNonDeleted()
		{
			var comments = await _context.Comments
																		.Include(x => x.Doctor)
																		.Include(a => a.Article)
																		.Where(a => !a.IsDeleted)
																		.ToListAsync();

			if (comments.Any())
			{
				return new DataResult<CommentListDto>(ResultStatus.Success, new CommentListDto
				{
					Comments = comments,
					ResultStatus = ResultStatus.Success,
				});
			}
			return new DataResult<CommentListDto>(ResultStatus.Error, "No comments found", null);
		}

		public async Task<IDataResult<CommentListDto>> GetAllByNonDeletedAndActive()
		{
			var comments = await _context.Comments
																		.Include(c => c.Doctor)
																		.Include(c => c.Article)
																		.Include(c => c.User)
																		.Where(c => !c.IsDeleted && c.IsActive).ToListAsync();

			if (comments.Any())
			{
				return new DataResult<CommentListDto>(ResultStatus.Success, new CommentListDto
				{
					Comments = comments,
					ResultStatus = ResultStatus.Success,
				});
			}
			return new DataResult<CommentListDto>(ResultStatus.Error, "No comments found", null);
		}

		public async Task<IResult> HardDelete(int commentId)
		{
			var comment = await _context.Comments.FirstOrDefaultAsync(a => a.Id == commentId);
			if (comment != null)
			{
				_context.Comments.Remove(comment);
				return new Result(ResultStatus.Success, "Comment deleted from database successfully.");
			}
			return new Result(ResultStatus.Error, "No comment found.");
		}

		public async Task<IResult> Update(CommentUpdateDto commentUpdateDto, int modifiedById)
		{
			var comment = _mapper.Map<Comment>(commentUpdateDto);
			comment.ModifiedById = modifiedById;
			_context.Comments.Update(comment);  //hocaya sor
			await _context.SaveChangesAsync();
			return new Result(ResultStatus.Success,"Comment updated successfully.");
		}
	}
}
