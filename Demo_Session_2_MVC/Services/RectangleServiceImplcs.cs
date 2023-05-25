namespace Demo_Session_2_MVC.Services;

public class RectangleServiceImplcs : RectangService
{
    private CeculaService ceculaService;
    public RectangleServiceImplcs(CeculaService _ceculaService)
    {
        ceculaService = _ceculaService;
    } 
    public int chuVi(int a, int b) {
        return ceculaService.Mul(ceculaService.Add(a,b),2); 
    }
    public int dientich(int a, int b)
    {
        return ceculaService.Mul(a,b);
    }
}
