using Ecommerce.Repository;
using Ecommerce.Repository.Models;

namespace Ecommerce.Services
{
    public class ImmagineServices
    {
        private readonly ShopDbContext _dbContext;

        public ImmagineServices(ShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Immagine> GetImgs()
        {
            List<Immagine> imgs = _dbContext.Immagines.ToList();
            return imgs;
        }

        public void UploadImg()
        {
            Immagine IphoneImg = new Immagine();
            IphoneImg.Id = 1;
            IphoneImg.Link = "/img/iphone1.png";
            IphoneImg.IdProdotto = 1;
            _dbContext.Immagines.Add(IphoneImg);
            _dbContext.SaveChanges();
            Immagine IphoneImg2 = new Immagine();
            IphoneImg2.Id = 2;
            IphoneImg2.Link = "/img/iphone2.png";
            IphoneImg2.IdProdotto = 1;
            _dbContext.Immagines.Add(IphoneImg2);
            _dbContext.SaveChanges();
        }

    }
}
