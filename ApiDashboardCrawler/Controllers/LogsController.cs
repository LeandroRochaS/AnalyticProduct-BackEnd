using ApiDashboardCrawler.Data;
using ApiDashboardCrawler.models;
using ApiDashboardCrawler.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiDashboardCrawler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase

    {
        private readonly dbbenchdashboardContext _dbcontext;

        public LogsController(dbbenchdashboardContext dbcontext)
        {
            _dbcontext = dbcontext;
        }




        // GET: api/<LogsController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var logs  =  _dbcontext.Logbenchdashboards.ToList();
            return Ok(logs);
        }

        // POST api/<LogsController>
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] InsertLogDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            var log = new Logbenchdashboard
            {
                Codigorobo = model.Codigorobo,
                Nomedev = model.Nomedev,
                Nomeproduto = model.Nomeproduto,
                Valor1 = model.Valor1,
                Valor2 = model.Valor2,
                Economia = model.Economia,
                Dataatualizacao = DateTime.Now
            };

            _dbcontext.Logbenchdashboards.Add(log);
            await _dbcontext.SaveChangesAsync();


            return Created("", log);

        }

        [HttpGet("economia-por-robo")]
        public async Task<IActionResult> EconomiaPorRobo()
        {
            try
            {
                var query = await _dbcontext.Logbenchdashboards
                    .GroupBy(log => log.Codigorobo)
                    .Select(g => new
                    {
                        CodigoRobo = g.Key,
                        EconomiaTotal = g.Sum(x => x.Economia)
                    })
                    .ToListAsync();

                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("produto-mais-economico")]
        public async Task<IActionResult> ProdutoMaisEconomico()
        {
            try
            {
                var produtoMaisEconomico = await _dbcontext.Logbenchdashboards
                    .OrderBy(log => log.Economia)
                    .FirstOrDefaultAsync();

                var resultado = new List<object>
        {
            new { produtoMaisEconomico.Nomeproduto, economia = produtoMaisEconomico.Economia }
        };

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("produto-menos-economico")]
        public async Task<IActionResult> ProdutoMenosEconomico()
        {
            try
            {
                var produtoMenosEconomico = await _dbcontext.Logbenchdashboards
                    .OrderByDescending(log => log.Economia)
                    .FirstOrDefaultAsync();

                var resultado = new List<object>
        {
            new { produtoMenosEconomico.Nomeproduto, economia = produtoMenosEconomico.Economia }
        };

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        [HttpGet("top-10-produtos-economicos")]
        public async Task<IActionResult> Top10ProdutosEconomicos()
        {
            try
            {
                var top10Produtos = await _dbcontext.Logbenchdashboards
                    .OrderBy(log => log.Economia)
                    .Take(10)
                    .Select(log => new { log.Nomeproduto, log.Economia })
                    .ToListAsync();



                return Ok(top10Produtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("total-economia")]
        public async Task<IActionResult> TotalEconomia()
        {
            try
            {
                var totalEconomia = await _dbcontext.Logbenchdashboards
                    .SumAsync(log => log.Economia);

                var resultado = new List<object>
            {
                new { label = "total economizado", revenue = totalEconomia }
            };

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }



}

