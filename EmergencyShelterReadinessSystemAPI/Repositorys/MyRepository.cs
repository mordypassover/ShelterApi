using EmergencyShelterReadinessSystemAPI.Data;

namespace EmergencyShelterReadinessSystemAPI.Repositorys;

public class MyRepository:IRepository
{
    MyDbContext _dbContext;

    public MyRepository(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }


}

