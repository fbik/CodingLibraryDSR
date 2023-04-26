using Web.Pages.Problems.Models;

namespace Web.Pages.Problems.Service;

public interface IProblemsService
{
   Task<IEnumerable<ProblemsListItem>> GetProblems(int offset = 0, int limit = 10);
   Task<ProblemsListItem> GetProblems(int ProblemsId);
   Task AddProblems(ProblemsModel model);
   Task EditProblems(Guid ProblemsUid, ProblemsModel model);
   Task DeleteProblems(Guid ProblemsUid);

   Task<IEnumerable<CategoriesModel>> GetCategoriesList();
   Task<IEnumerable<LanguagesModel>> GetLanguagesList();

}