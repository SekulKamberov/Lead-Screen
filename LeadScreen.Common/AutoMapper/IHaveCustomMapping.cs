namespace LeadScreen.Common.AutoMapper
{
    using AutoMapper;
    using global::AutoMapper;

    public interface IHaveCustomMapping
    {
        void ConfigureMapping(Profile profile);
    }
}
