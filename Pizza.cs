public class Pizza
{
    private string Sabor;
    private string Tamanho;
    public double Preco;

    public Pizza(string sabor, string tamanho, double preco){
        this.Sabor = sabor;
        this.Tamanho = tamanho;
        this.Preco = preco;
    }

    public string showSabor(){
        return Sabor;
    }

}
