using Example.Domain.Interfaces;
using Example.Infrastructure.Interfaces;
using Example.Infrastructure.Models;

namespace Example.Domain;

public class FarmerDomain : IFarmerDomain
{
    private IFarmerInfrastructure farmerInfrastructure;
    private IFarmlandInfrastructure farmlandInfrastructure;

    public FarmerDomain(IFarmerInfrastructure farmerInfrastructure, IFarmlandInfrastructure farmlandInfrastructure)
    {
        this.farmerInfrastructure = farmerInfrastructure;
        this.farmlandInfrastructure = farmlandInfrastructure;
    }

    public Task<bool> SaveAsync(Farmer farmer)
    {
        if (!IsValidData(farmer))
            throw new Exception("This username or email is already use");
        if (!AreLocationUnique(farmer))
            throw new Exception("Farmlands' location are not unique");
        if (!AreValidLocation(farmer))
            throw new Exception("One or more farmlands already have the same location");
        return farmerInfrastructure.SaveAsync(farmer);
    }

    private bool IsValidData(Farmer farmer)
    {
        return farmerInfrastructure.GetByEmail(farmer.Email) == null &&
               farmerInfrastructure.GetByUsername(farmer.Username) == null;
    }

    private bool AreValidLocation(Farmer farmer)
    {
        var validFarmlands = farmer.Farmlands.Select(farmland => farmlandInfrastructure.GetByLocation(farmland) != null);
        return validFarmlands.Count() == farmer.Farmlands.Count();
    }

    private bool AreLocationUnique(Farmer farmer)
    {
        var locationCombinations = farmer.Farmlands
            .Select(farmland => new { farmland.Altitude, farmland.Longitude, farmland.Latitude })
            .ToList();
        
        bool hasDuplicateLocation = locationCombinations
            .GroupBy(location => new { location.Altitude, location.Longitude, location.Latitude })
            .Any(group => group.Count() > 1);
        
        return !hasDuplicateLocation;
    }
}