using consultaCep_backend.dto;

namespace consultaCep_backend.interactor
{
    public interface ISearchByZipCodeInteractor
    {
        public Task<SearchResultCepDto> SearchByZipCode(string code);
    }
}
