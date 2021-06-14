namespace M120_226B_UTT_Project.Helper
{
    public interface IField
    {
        FieldState FieldState { get; }
        void reset();
    }
}
