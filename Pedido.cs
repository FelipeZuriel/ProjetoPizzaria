public class Pedido
{
    private static int contagemPedido = 1;
    private int idPedido = contagemPedido;
    public List<Pizza>? pizza;
    private string cliente;
    private bool bordaRecheada;
    private List<Refrigerante>? refrigerante;
    private Nota nota = new Nota();
    public double valor;

    public Pedido(Pizza p, string c, bool b){
        this.pizza?.Add(p);
        this.cliente = c;
        this.bordaRecheada = b;

        contagemPedido++;
    }

    public int showId(){
        return idPedido;
    }

    public string showNota(){
        return nota.status;
    }

    public void adicionarPizza(Pizza p){
        this.pizza?.Add(p);
    }

    public void adicionarRefrigerante(Refrigerante r){
        if(r != null){
            this.refrigerante?.Add(r);
        }
    }

    public string excluirRefri(string rEx){
        var i = 0;
        do{
            if(refrigerante?[i].showMarca() == rEx){
                refrigerante.RemoveAt(i);
                return "Refrigerante Excluido";
            }
        } while(i < refrigerante?.Count);
        return "Este pedido não possui esse ou nenhum refrigerente";
    }

    public string excluirPizza(String pzz){
        for(var i = 0; i < pizza?.Count; i++){
            if(pizza[i].showSabor() == pzz){
                pizza.RemoveAt(i);
                return "Pizza Excluida";
            }else{
                return "Este pedido não possui essa ou nenhuma pizza";
            }
        }
        return "Pedido não possui pizza";
    }

    public double precoPedido(){
        Console.WriteLine("-----");
        Console.WriteLine(pizza?[0].Preco);
        Console.WriteLine("-----");
        Console.ReadLine();
        double total = 0;
        if(this.pizza?.Count > 0){
            var i = 0;
            do{
            total += pizza[i].Preco;
            i++;
            } while(i < pizza?.Count);
        }
        if(this.refrigerante?.Count > 0){
            var i = 0;
            do{
            total += refrigerante[i].rPreco;
            i++;
            } while(i < refrigerante?.Count);
        }
        if(this.bordaRecheada == true){
            total += 3;
        }
        return total;
    }

    public string verificarPagamento(double valorCliente){
        this.valor = valorCliente;
        var valorP = precoPedido();
        if(valorP == valorCliente || valorP < valorCliente){
            nota.status = "PAGA";
            return "Pedido Finalizado!";
        }else{
            return "Valor insuficiente";
        }
    }
}