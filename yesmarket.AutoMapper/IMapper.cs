namespace yesmarket.AutoMapper
{
    public interface IMapper<in TSource, out TDestination>
    {
        TDestination MapFrom(TSource source);
    }
}
