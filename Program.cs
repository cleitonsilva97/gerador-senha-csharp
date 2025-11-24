int tamanho;

while (true)
{
    Console.Write("Digite o tamanho da senha: ");

    if (int.TryParse(Console.ReadLine(), out tamanho) && tamanho > 0)
        break;

    Console.WriteLine("Tamanho inválido. Digite um número inteiro maior que zero.\n");
}

string LerSN(string mensagem)
{
    while (true)
    {
        Console.Write(mensagem);
        string resposta = Console.ReadLine().ToLower();

        if (resposta == "s" || resposta == "n")
            return resposta;

        Console.WriteLine("Digite apenas 's' ou 'n'.\n");
    }
}

string respMaius = LerSN("Incluir letras maiúsculas? (s/n): ");
bool incluirMaius = respMaius == "s";

string respMinus = LerSN("Incluir letras minúsculas? (s/n): ");
bool incluirMinus = respMinus == "s";

string respNum = LerSN("Incluir números? (s/n): ");
bool incluirNum = respNum == "s";

string respSimbolos = LerSN("Incluir símbolos? (s/n): ");
bool incluirSimbolos = respSimbolos == "s";

Console.WriteLine($"\nMaiúsculas: {incluirMaius}");
Console.WriteLine($"Minúsculas: {incluirMinus}");
Console.WriteLine($"Números: {incluirNum}");
Console.WriteLine($"Símbolos: {incluirSimbolos}");

if (!incluirMaius && !incluirMinus && !incluirNum && !incluirSimbolos)
{
    Console.WriteLine("\nErro: Você deve escolher pelo menos um tipo de caractere.");
    return;
}

string chars = "";

if (incluirMaius)
    chars += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

if (incluirMinus)
    chars += "abcdefghijklmnopqrstuvwxyz";

if (incluirNum)
    chars += "0123456789";

if (incluirSimbolos)
    chars += "!@#$%^&*()-_=+[]{};:,.<>?";

Console.WriteLine($"\nCaracteres disponíveis: {chars}");

Random rnd = new Random();
var senhaBuilder = new System.Text.StringBuilder();

for (int i = 0; i < tamanho; i++)
{
    int index = rnd.Next(chars.Length);
    senhaBuilder.Append(chars[index]);
}

string senha = senhaBuilder.ToString();
Console.WriteLine($"\nSenha gerada: {senha}");
