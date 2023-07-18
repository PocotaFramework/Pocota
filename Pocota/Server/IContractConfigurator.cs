using Microsoft.AspNetCore.Mvc;

namespace Net.Leksi.Pocota.Server;

public interface IContractConfigurator
{
    void Configure(IServiceCollection services);
}
