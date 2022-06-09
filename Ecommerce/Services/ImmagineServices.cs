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
            Immagine IphoneImg3 = new Immagine();
            IphoneImg2.Id = 3;
            IphoneImg2.Link = "/img/iphone3.png";
            IphoneImg2.IdProdotto = 1;
            _dbContext.Immagines.Add(IphoneImg2);
            _dbContext.SaveChanges();

            for (int i = 0; i < 3; i++)
            {
                Immagine mela = new Immagine();
                mela.Id = _dbContext.Immagines.Count()+1;
                mela.Link = "/img/mela" + (i + 1) + ".png";
                mela.IdProdotto = 2;
                _dbContext.Immagines.Add(mela);
                _dbContext.SaveChanges();
            }

            for (int i = 0; i < 3; i++)
            {
                Immagine shirt = new Immagine();
                shirt.Id = _dbContext.Immagines.Count() + 1;
                shirt.Link = "/img/shirt" + (i + 1) + ".png";
                shirt.IdProdotto = 3;
                _dbContext.Immagines.Add(shirt);
                _dbContext.SaveChanges();
            }
        }

    }
}
