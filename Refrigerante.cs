public class Refrigerante
{
    private string Marca;
    public double rPreco;
    private string mL;

    public Refrigerante(string m, double rP, string ml){
        this.Marca = m;
        this.rPreco = rP;
        this.mL = ml;
    }

    public string showMarca(){
        return Marca;
    }

}