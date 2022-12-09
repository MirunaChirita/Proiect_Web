using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect_Web.Data;
namespace Proiect_Web.Models
{
    public class CategorieSportPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Proiect_WebContext context,
        Rezervare rezervare)
        {
            var allCategories = context.Categorie;
            var RezervareCategories = new HashSet<int>(
            rezervare.CategorieSport.Select(c => c.CategorieID)); //
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategorieID = cat.ID,
                    Nume = cat.CategorieNume,
                    Assigned = RezervareCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateSportCategories(Proiect_WebContext context,
        string[] selectedCategories, Rezervare rezervareToUpdate)
        {
            if (selectedCategories == null)
            {
                rezervareToUpdate.CategorieSport = new List<CategorieSport>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var rezervareCategories = new HashSet<int>
            (rezervareToUpdate.CategorieSport.Select(c => c.Categorie.ID));
            foreach (var cat in context.Categorie)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!rezervareCategories.Contains(cat.ID))
                    {
                        rezervareToUpdate.CategorieSport.Add(
                        new CategorieSport
                        {
                            RezervareID = rezervareToUpdate.ID,
                            CategorieID = cat.ID
                        });
                    }
                }
                else
                {
                    if (rezervareCategories.Contains(cat.ID))
                    {
                        CategorieSport courseToRemove
                        = rezervareToUpdate
                        .CategorieSport
                        .SingleOrDefault(i => i.CategorieID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    

    }
}
