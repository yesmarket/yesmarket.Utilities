namespace yesmarket.AutoMapping
{
    public interface IMapper<in TSource, out TDestination>
    {
        TDestination MapFrom(TSource source);
    }
}
