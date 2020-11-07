using FindaBeer.Services.Images;
using FindaBeer.Services.Services.Beers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FindaBeer.Staging
{
    /// <summary>
    /// Serviço para popular o banco de dados no ambiente de desenvolvimento.
    /// </summary>
    public sealed class StagingService
    {
        private readonly BeersService beersService;

        private readonly ImagesService imagesService;

        private readonly IConfiguration config;

        public StagingService(IConfiguration config, BeersService beersService, ImagesService imagesService)
        {
            this.beersService = beersService;
            this.config = config;
            this.imagesService = imagesService;
        }

        /// <summary>
        /// Popula a base de dados com dados para o ambiente de desenvolvimento.
        /// </summary>
        internal async Task AddStagingData()
        {
            var client = new MongoClient(config.GetConnectionString("FindaBeerDB"));
            client.DropDatabase("FindaBeerDB");

            await beersService.Create(new Beer()
            {
                Name = "Antarctica Pilsen",
                Description = "Antarctica surgiu como uma fábrica de gelo e passou a produzir cerveja um ano depois, em 1889. É o complemento perfeito para momentos de prazer e para descontrair em boa companhia. Leve, porém, com uma personalidade própria. Seu aroma levemente frutado e o balanço entre a acidez e o dulçor são bastante característicos.",
                Ingredients = new List<string>() { "água", "malte", "milho", "lúpulo" },
                Pairings = "Combina com petiscos como castanhas e amendoins, mas também aves e carne grelhada.",
                AlcoholContent = 0.047f,
                TemperatureMin = 0,
                TemperatureMax = 4,
                Color = 10,
                DefaultImage = imagesService.ToBase64(global::FindaBeer.Staging.Properties.Resources.antarctica)
            });

            await beersService.Create(new Beer()
            {
                Name = "Antarctica Cristal",
                Description = "Antarctica Cristal foi a primeira cerveja brasileira com garrafa transparente, destacando, assim, sua coloração clara, típica das Pale Lagers. A Cristal possui aroma acentuado, sabor encorpado e levemente amargo, mas não deixa a refrescância de lado — aspecto importante deste tipo de cerveja.",
                Ingredients = new List<string>() { "água", "malte", "milho", "lúpulo" },
                Pairings = "Combina com petiscos como queijos leves, castanhas, amendoins.",
                AlcoholContent = 0.054f,
                TemperatureMin = 0,
                TemperatureMax = 4,
                Color = 10,
                DefaultImage = imagesService.ToBase64(global::FindaBeer.Staging.Properties.Resources.antarctica_cristal)
            });

            await beersService.Create(new Beer()
            {
                Name = "Antarctica Subzero",
                Description = "É uma cerveja tipo pilsner, que passa por um sistema de dupla filtração a -2 °C. Durante este processo, a linha de produção fica coberta por uma fina camada de gelo e a cerveja chega perto do ponto de congelamento. O resultado é uma bebida saborosa e mais refrescante.",
                Ingredients = new List<string>() { "água", "malte", "milho", "lúpulo" },
                Pairings = "Combina com petiscos como castanhas e amendoins, mas também aves e carne grelhada.",
                AlcoholContent = 0.045f,
                TemperatureMin = 0,
                TemperatureMax = 4,
                Color = 10,
                DefaultImage = imagesService.ToBase64(global::FindaBeer.Staging.Properties.Resources.antarctica_subzero)
            });

            await beersService.Create(new Beer()
            {
                Name = "Brahma Chopp",
                Description = "A Brahma está no Brasil desde 1888. Nasceu lá na Sapucaí, no Rio de Janeiro. E de lá cresceu para o mundo, para levar o sabor autêntico de cerveja brasileira, com espuma cremosa e persistente, amargor presente e ligeiramente encorpada.",
                Ingredients = new List<string>() { "água", "malte", "milho", "lúpulo" },
                Pairings = "Por ser uma cerveja leve e bem carbonatada, combina com queijos pouco condimentados, saladas, frutos do mar e petiscos fritos.",
                AlcoholContent = 0.048f,
                TemperatureMin = 0,
                TemperatureMax = 4,
                Color = 10,
                DefaultImage = imagesService.ToBase64(global::FindaBeer.Staging.Properties.Resources.brahma)
            });

            await beersService.Create(new Beer()
            {
                Name = "Brahma Extra Weiss",
                Description = "A Cerveja Brahma Extra Weiss é feita com malte de trigo. Por isso, tem uma cor clara e opaca. Já a espuma é tão extraordinária quanto cremosa. O sabor? Incrível: frutado para banana, maçã e especiarias. É uma cerveja refrescante, com graduação alcoólica moderada e uma leve acidez ideal para combinar com queijo minas, aves, peixes e saladas.",
                Ingredients = new List<string>() { "água", "malte de trigo", "malte de cevada", "milho", "lúpulo" },
                Pairings = "Cerveja de trigo refrescante e leve, harmoniza muito bem com comidas leves como saladas, frutos do mar e banana caramelada, mas também fazem um belo par com comidas apimentadas.",
                AlcoholContent = 0.049f,
                TemperatureMin = 4,
                TemperatureMax = 8,
                Color = 20,
                DefaultImage = imagesService.ToBase64(global::FindaBeer.Staging.Properties.Resources.brahma_extra_weiss)
            });

            await beersService.Create(new Beer()
            {
                Name = "Brahma Malzbier",
                Description = "A Brahma Malzbier é para quem ama equilíbrio: é leve, mas encorpada. A Brahma Malzbier é também para quem gosta de um sabor adocicado no paladar, que aqui é por conta do caramelo na composição. E, por fim, a Brahma Malzbier é ótima para quem quer harmonizar cerveja com sobremesas, como chocolates e tortas.",
                Ingredients = new List<string>() { "água", "malte", "milho", "açúcar de cana", "lúpulo", "corante caramelo III INS 150c" },
                Pairings = "As notas de malte torrados deixam essa cerveja excelente para harmonizar com sobremesas, como torta de chocolate e sorvete de creme.",
                AlcoholContent = 0.038f,
                TemperatureMin = 8,
                TemperatureMax = 12,
                Color = 90,
                DefaultImage = imagesService.ToBase64(global::FindaBeer.Staging.Properties.Resources.brahma_malzbier)
            });

            await beersService.Create(new Beer()
            {
                Name = "Colorado Appia",
                Description = "A palavra Appia vem do latim e significa abelha. O nome perfeito para a primeira cerveja do Brasil a utilizar mel em sua fórmula. Uma combinação exótica que, além do mel das laranjeiras, é feita a partir da melhor cevada, trigos maltados e nossa exclusiva levedura de alta fermentação. Doce, encorpada e refrescante, é perfeita para quem busca novos e diferentes sabores. Colorado Appia ganhou por três anos consecutivos a Medalha de bronze no festival Brasileiro de Cerveja (2013, 2014 e 2015).",
                Ingredients = new List<string>() { "água", "mel" },
                Pairings = "Por ser uma cerveja leve, a Colorado Appia vai combinar muito bem comidas mais leves como pernil, saladas, frango, massas e queijo brie.",
                AlcoholContent = 0.055f,
                TemperatureMin = 4,
                TemperatureMax = 8,
                Color = 10,
                DefaultImage = imagesService.ToBase64(global::FindaBeer.Staging.Properties.Resources.appia)
            });

            await beersService.Create(new Beer()
            {
                Name = "Colorado Berthô",
                Description = "A Cerveja Colorado Berthô é uma American Brown Ale feita com Bertholletia Excelsa. Mas pode chamá-la simplesmente de Berthô, a cerveja que foi buscar na culinária mais diversificada do Brasil o seu ingrediente especial: a castanha-do-Pará. O tom adocicado do malte, combinado com o amargor dos lúpulos especiais e da castanha, criam um sabor único e inconfundível, assim como a cultura paraense.",
                Ingredients = new List<string>() { "água", "malte de cevada", "aveia", "açúcar mascavo", "castanha do pará", "lúpulo", "fermento" },
                Pairings = "Harmoniza com queijo Gouda, hambúrguer e sobremesas à base de castanhas.",
                AlcoholContent = 0.08f,
                TemperatureMin = 8,
                TemperatureMax = 16,
                Color = 70,
                DefaultImage = imagesService.ToBase64(global::FindaBeer.Staging.Properties.Resources.colorado_bertho)
            });

            await beersService.Create(new Beer()
            {
                Name = "Colorado Eugênia",
                Description = "Eugênia é uma cerveja do estilo Session IPA, com aromas marcantes dos lúpulos americanos, alemães e franceses, com um ingrediente especial: a fruta Uvaia, típica da Mata Atlântica, rica em vitamina C e A, super aromática e com sabor cítrico. A Cerveja Colorado Eugênia é leve, refrescante e amarga na medida (40 IBU). Desiberne, cerveja pode ter fruta!",
                Ingredients = new List<string>() { "água", "malte", "polpa de uvaia", "lúpulo", "fermento" },
                Pairings = "Harmoniza com ceviche, comida mexicana (tacos, quesadilla), chicken wings, petiscos, churrasco e sobremesas ácidas.",
                AlcoholContent = 0.045f,
                TemperatureMin = 0,
                TemperatureMax = 4,
                Color = 10,
                DefaultImage = imagesService.ToBase64(global::FindaBeer.Staging.Properties.Resources.colorado_eugenia)
            });

            await beersService.Create(new Beer()
            {
                Name = "Colorado Indica",
                Description = "A Cerveja Colorado Indica foi a primeira India Pale Ale produzida no Brasil e é baseada na fórmula utilizada pelos soldados ingleses em sua longa viagem marítima até a Índia. Detalhe: com um toque especial da rapadura. Não por acaso, foi eleita pela revista Prazeres da Mesa a Cerveja do Ano e ainda recebeu 3 estrelas na publicação inglesa Pocket Beer Guide, o mais respeitado guia de cervejas do mundo, do grande crítico de cervejas Michael Jackson.",
                Ingredients = new List<string>() { "água", "malte", "rapadura", "lúpulo", "fermento" },
                Pairings = "O aroma de lúpulo da Colorado Indica complementa as notas herbais dos queijos azuis, como o gorgonzola, em uma harmonização por semelhança.",
                AlcoholContent = 0.07f,
                TemperatureMin = 8,
                TemperatureMax = 12,
                Color = 30,
                DefaultImage = imagesService.ToBase64(global::FindaBeer.Staging.Properties.Resources.indica)
            });
        }
    }
}
