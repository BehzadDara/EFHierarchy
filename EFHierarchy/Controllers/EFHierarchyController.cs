using EFHierarchy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFHierarchy.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EFHierarchyController : ControllerBase
    {
        private readonly EFHierarchyDBContext _dbContext;

        public EFHierarchyController(EFHierarchyDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public void Post()
        {
            #region TPC

            var TPC1 = new TPCChild1
            {
                TPCChild1Field = "TPCChild1Value",
                TPCParentField = "TPCParent1Value",
            };
            _dbContext.Add(TPC1);
            _dbContext.SaveChanges();

            var TPC2 = new TPCChild2
            {
                TPCChild2Field = "TPCChild2Value",
                TPCParentField = "TPCParent2Value",
            };
            _dbContext.Add(TPC2);
            _dbContext.SaveChanges();

            var TPC3 = new TPCChild1
            {
                TPCChild1Field = "TPCChild1Value",
                TPCParentField = "TPCParent1Value",
            };
            _dbContext.Add(TPC3);
            _dbContext.SaveChanges();

            /*
            Test the output using this query:

            SELECT * FROM [dbo].[TPCChild1]
            SELECT * FROM [dbo].[TPCChild2]

            */

            #endregion

            #region TPH

            var TPH1 = new TPHChild1
            {
                TPHChild1Field = "TPHChild1Value",
                TPHParentField = "TPHParent1Value",
            };
            _dbContext.Add(TPH1);
            _dbContext.SaveChanges();

            var TPH2 = new TPHChild2
            {
                TPHChild2Field = "TPHChild2Value",
                TPHParentField = "TPHParent2Value",
            };
            _dbContext.Add(TPH2);
            _dbContext.SaveChanges();

            var TPH3 = new TPHChild1
            {
                TPHChild1Field = "TPHChild1Value",
                TPHParentField = "TPHParent1Value",
            };
            _dbContext.Add(TPH3);
            _dbContext.SaveChanges();

            /*
            Test the output using this query:

            SELECT * FROM [dbo].[TPHParent]

            */

            #endregion

            #region TPT

            var TPT1 = new TPTChild1
            {
                TPTChild1Field = "TPTChild1Value",
                TPTParentField = "TPTParent1Value",
            };
            _dbContext.Add(TPT1);
            _dbContext.SaveChanges();

            var TPT2 = new TPTChild2
            {
                TPTChild2Field = "TPTChild2Value",
                TPTParentField = "TPTParent2Value",
            };
            _dbContext.Add(TPT2);
            _dbContext.SaveChanges(); 
            
            var TPT3 = new TPTChild1
            {
                TPTChild1Field = "TPTChild3Value",
                TPTParentField = "TPTParent3Value",
            };
            _dbContext.Add(TPT3);
            _dbContext.SaveChanges();

            /*
            Test the output using this query:

            SELECT * FROM [dbo].[TPTParent]
            SELECT * FROM [dbo].[TPTChild1]
            SELECT * FROM [dbo].[TPTChild2]

            */

            #endregion
        }
    }
}
