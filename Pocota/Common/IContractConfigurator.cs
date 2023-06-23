using Microsoft.Extensions.DependencyInjection;

namespace Net.Leksi.Pocota.Common;

public interface IContractConfigurator
{
    void Configure(IServiceCollection services);
}
