using FluentValidation;

namespace WebApi.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQureyValidator: AbstractValidator<GetGenreDetailQurey>
    {
        public GetGenreDetailQureyValidator()
        {
            RuleFor(query=> query.GenreId).GreaterThan(0);
        }
    }
}