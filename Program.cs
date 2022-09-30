List<Refrigerante> listaRefrigerante = new List<Refrigerante>();
List<Pizza> listaPizza = new List<Pizza>();
List<Pedido> listaPedido = new List<Pedido>();

// Refrigerante reF1 = new Refrigerante("Coca", 3.50);
// listaRefrigerante.Add(reF1);
// Refrigerante reF2 = new Refrigerante("Fanta-Laranja", 5.50);
// listaRefrigerante.Add(reF2);
// Refrigerante reF3 = new Refrigerante("Dolly- Guaraná", 1.50);
// listaRefrigerante.Add(reF3);

// Pizza pizza2 = new Pizza("Mussarela", "Média", 29.99);
// listaPizza.Add(pizza2);
// Pizza pizza3 = new Pizza("Brigadeiro", "Pequena", 35);
// listaPizza.Add(pizza3);

Console.Clear();

Console.WriteLine("Bem-vindo a Pizzaria Zuriel!!");
Console.WriteLine("--------------------------------------------------");
Console.WriteLine("-                                                -");
Console.WriteLine("-          Clique enter para continuar           -");
Console.WriteLine("-                                                -");
Console.WriteLine("--------------------------------------------------");
Console.ReadLine();

Acoes();

void Acoes(){
    Console.Clear();
    var auxL = 2;
    while(auxL > 1){
        Console.Clear();
        Console.WriteLine("O que deseja fazer?");
        Console.WriteLine("1 - Cadastrar um Refrigerante");
        Console.WriteLine("2 - Cadastrar uma Pizza");
        Console.WriteLine("3 - Criar um pedido");
        Console.WriteLine("4 - Editar pedido");
        Console.WriteLine("5 - Sair do sistema");
        var acao = int.Parse(Console.ReadLine());
        switch(acao) {
                case 1:
                    cadastrarRefrigerante();
                    break;
                case 2:
                    cadastrarPizza();
                    break;
                case 3:
                    criarPedido();
                    Console.WriteLine("Deseja realizar alguma outra ação?");
                    Console.WriteLine("1 - Sim");
                    Console.WriteLine("2 - Não");
                    var auxStart = int.Parse(Console.ReadLine());
                    if(auxStart == 1){
                        auxL = 2;
                    }else if(auxStart == 2){
                        Console.WriteLine("Obrigado por utilizar nosso sistema!");
                        Console.WriteLine("Volte Sempre");
                        auxL = 1;
                    }else{
                        Console.WriteLine("Valor incorreto!! Tente novamente");
                    }
                    break;
                case 4:
                    if(listaPedido == null){
                        Console.WriteLine("Nenhum pedido criado ainda");
                    }else{
                        Console.WriteLine("Digite o número do pedido");
                        var edit = int.Parse(Console.ReadLine());
                        for(var i = 0; i < listaPedido.Count; i++){
                            if(listaPedido[i].showId() == edit){
                                Console.WriteLine("Pedido encontrado - Enter para continuar");
                                Console.ReadLine();
                                editarPedido(listaPedido[i]);
                            }
                        }
                    }
                    break;
                case 5:
                    Console.WriteLine("Obrigado por utilizar nosso sistema!");
                    Console.WriteLine("Volte Sempre");
                    auxL = 1;
                    break;
                default:
                    Console.WriteLine("Escolha uma das opções disponíveis");
                    Console.ReadLine();
                    break;
        }
    }
}

void Acoes2(Pedido pp){
    Console.Clear();
    Console.WriteLine("Deseja fechar ou editar o pedido?");
    Console.WriteLine("1 - Editar");
    Console.WriteLine("2 - Fechar");
    var auxAc2 = int.Parse(Console.ReadLine());
    if(auxAc2 == 1){
        editarPedido(pp);
    }else if(auxAc2 == 2){
        fecharPedido(pp);
    }
}

void cadastrarRefrigerante(){
    var verifRefri = true;
    while(verifRefri){
        Console.Clear();
        Console.WriteLine("Digite a marca do Refrigerante:");
        var marcaR = Console.ReadLine();
        Console.WriteLine("Preço:");
        var aux = Console.ReadLine();
        double precoR = Convert.ToDouble(aux);
        Console.WriteLine("Tamanho (Ml ou L):");
        var tamanhoR = Console.ReadLine();
        var refri = new Refrigerante(marcaR, precoR, tamanhoR);
        listaRefrigerante.Add(refri);

        Console.WriteLine("Refrigerante cadastrado!");
        Console.WriteLine("Deseja cadastrar outro? Digite Sim ou não");
        var auxRefri = Console.ReadLine();
        if(auxRefri == "Sim" || auxRefri == "sim"){
            verifRefri = true;
        }else{
            verifRefri = false;
        }
    }
    Console.Clear();
}

void cadastrarPizza(){
    var verifPizza = true;
    while(verifPizza){
        Console.Clear();
        Console.WriteLine("Digite o sabor:");
        var sabor = Console.ReadLine();
        Console.WriteLine("Tamanho:");
        var tamanhoP = Console.ReadLine();
        Console.WriteLine("Preço:");
        var aux = Console.ReadLine();
        double precoP = Convert.ToDouble(aux);
        var pizza = new Pizza(sabor, tamanhoP, precoP);
        listaPizza.Add(pizza);

        Console.WriteLine("Pizza cadastrada!");
        Console.WriteLine("Deseja cadastrar outra? Digite Sim ou não");
        var auxPiza = Console.ReadLine();
        if(auxPiza == "Sim" || auxPiza == "sim"){
            verifPizza = true;
        }else{
            verifPizza = false;
        }
    }
    Console.Clear();
}

Pizza adicionarPizza(){
    Console.WriteLine("\nDigite o sabor da pizza:");
    var saborPizza = Console.ReadLine();
    while(1 > 0){
        if(string.IsNullOrEmpty(saborPizza)){
            Console.WriteLine("Você não digitou nada, favor digitar um sabor");
            Console.ReadLine();
        }else{
            for(var i = 0; i < listaPizza.Count; i++){
                if(listaPizza[i].showSabor() == saborPizza){
                    Console.WriteLine("Sabor adicionado");
                    return listaPizza[i];
                }
            }
        }
    }
}

Refrigerante adicionarRefri(){
    Console.WriteLine("\nDigite o refrigerante:");
    var auxRefri = Console.ReadLine();
    while(1 > 0){
        if(string.IsNullOrEmpty(auxRefri)){
            Console.WriteLine("Você não digitou nada, favor digitar refrigerante");
            Console.ReadLine();
        }else{
            for(var i = 0; i < listaRefrigerante.Count; i++){
                if(listaRefrigerante[i].showMarca() == auxRefri){
                    Console.WriteLine("Refrigerante adicionado");
                    Console.ReadLine();
                    return listaRefrigerante[i];
                }
            }
        }
    }
}


void criarPedido(){
    Console.Clear();
    var pizzaPedido = adicionarPizza();
    Console.WriteLine("Deseja Borda recheada? Digite Sim ou Não");
    var borda = Console.ReadLine();
    bool bordaYN; 
    if(borda == "Sim" || borda == "sim"){
        bordaYN = true;
    }else{
        bordaYN = false;
    }
    Console.WriteLine("Digite o nome do cliente:");
    var clientePedido = Console.ReadLine();
    if(clientePedido == null){
        clientePedido = "Anonimo";
    }
    Pedido pedi = new Pedido(pizzaPedido, clientePedido, bordaYN);
    listaPedido.Add(pedi);
    Console.WriteLine("Pedido Criado");
    Console.WriteLine("Id do pedido:"+ pedi.showId());


    Console.WriteLine("Deseja adicionar refrigerante ao pedido? Digite Sim ou Não");
    var auxAdd = Console.ReadLine();
    if(auxAdd == "Sim" || auxAdd == "sim"){
        var refrigeranteP = adicionarRefri();
        pedi.adicionarRefrigerante(refrigeranteP);
        Console.WriteLine("Refrigerante adicionado");
    }
    Acoes2(pedi);
}

void fecharPedido(Pedido p){
    Console.WriteLine("Vamo fechar o pedido!!");
    Console.WriteLine($"Preço total:{p.precoPedido()}  digite o valor do cliente:");
    var auxclo = true;
    do{
        var aux = Console.ReadLine();
        double precoInicial = Convert.ToDouble(aux);
        Console.WriteLine(p.verificarPagamento(precoInicial));
        if(p.verificarPagamento(precoInicial) == "Pedido Finalizado!"){
            Console.WriteLine("Pedido Pago! Volte sempre!");
            auxclo = false;
            break;
        }else{
            Console.WriteLine("Digite outro valor:");
        }
    } while(auxclo);
}

void editarPedido(Pedido pe){
    Console.Clear();
    var ajuda = 2;
    while(ajuda > 1){
        Console.Clear();
        Console.WriteLine("Deseja adicionar ou remover itens?");
        Console.WriteLine("1 - Adicionar");
        Console.WriteLine("2 - Remover");
        Console.WriteLine("3 - Finalizar");
        var opc = int.Parse(Console.ReadLine());
        if(opc == 1){
            adicionarItens(pe);
            Console.WriteLine("Adicionado com sucesso - Direcionando para fechar pedido;");
            Console.ReadLine();
        }else if(opc == 2){
            excluirItens(pe);
        }else if(opc == 3){
            Console.WriteLine("Direcionando para fechar pedido;");
            fecharPedido(pe);
            ajuda = 2;
        }else{
            Console.WriteLine("Nenhuma opção escolhida, direcionando para fechar pedido;");
            fecharPedido(pe);
            ajuda = 2;
        }
    }
}

void adicionarItens(Pedido p)
{
    if (p.showNota() == "PAGA")
    {
        Console.WriteLine("Pedido fechado, não há como editar!");
    }
    else
    {
        Console.WriteLine("Deseja adicionar o que:");
        Console.WriteLine("1 - Pizza");
        Console.WriteLine("2 - Refrigerante");
        var opcao = int.Parse(Console.ReadLine());
        switch (opcao)
        {
            case 1:
                var aux = adicionarPizza();
                p.adicionarPizza(aux);
                break;
            case 2:
                var aux1 = adicionarRefri();
                p.adicionarRefrigerante(aux1);
                break;
            default:
                Console.WriteLine("");
                break;
        }
    }
}

void excluirItens(Pedido p){
    Console.WriteLine("Deseja remover qual item?");
    Console.WriteLine("1 - Refrigerante");
    Console.WriteLine("2 - Pizza");
    var auxExc = int.Parse(Console.ReadLine());
    if(auxExc == 1){
        Console.WriteLine("Digite a marca do Refri que deseja remover:");
        var refriExcluir = Console.ReadLine();
        Console.WriteLine(p.excluirRefri(refriExcluir));
        Console.ReadLine();
    }else if(auxExc == 2){
        Console.WriteLine("Digite o sabor da pizza que deseja remover:");
        var pizzaExcluir = Console.ReadLine();
        Console.WriteLine(p.excluirPizza(pizzaExcluir));
        Console.ReadLine();
    }
}
