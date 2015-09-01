namespace yesmarket.AutoMapper
{
    public interface IDataContractMapper<TDataContract, TDomainObject>
    {
        TDomainObject MapToDomainObject(TDataContract source);
        TDataContract MapToDataContract(TDomainObject source);
    }
}