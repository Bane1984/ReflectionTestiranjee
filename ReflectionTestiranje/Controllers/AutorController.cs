using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ReflectionTestiranje.Models;

namespace ReflectionTestiranje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        /// <summary>
        /// Refleksija, Ime sklopa u kom se radi.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var assemblyName = assembly.GetName().Name;
            return Ok(assemblyName);
        }

        /// <summary>
        /// Refleksija, tip Autor klase koji je ocigledan i spisak propertija.
        /// </summary>
        /// <returns></returns>
        [HttpGet("getautor")]
        public (string, List<string>) GetAutor()
        {
            TypeInfo autorInfo = typeof(Autor).GetTypeInfo();
            string autorInfoString = autorInfo.ToString();
            IEnumerable<PropertyInfo> deklarisanaSvojstva = autorInfo.DeclaredProperties;
            List<string> sv = new List<string>();
            foreach (var svojstvra in deklarisanaSvojstva)
            {
                sv.Add(svojstvra.ToString());
            }

            return (autorInfoString, sv);
        }

        /// <summary>
        /// Broj svojstava u sklopu, ime imenskog prostora.
        /// </summary>
        /// <returns></returns>
        [HttpGet("getbrojproperties")]
        public IActionResult GetNoProperties()
        {
            TypeInfo autorInfo = typeof(Autor).GetTypeInfo();
            IEnumerable<PropertyInfo> autorSvojstva = autorInfo.DeclaredProperties;
            int brojSvojstava = autorSvojstva.Count();

            return Ok($"Sklop {autorInfo.Name} ima {brojSvojstava.ToString()} svojstava i nalazi se u {autorInfo.Namespace} imenskom prostoru.");
        }

        /// <summary>
        /// Uzimanje svih tipova u ovom projektu.
        /// </summary>
        /// <returns></returns>
        [HttpGet("getsvihtipova")]
        public IActionResult GetAllTypeProp()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var tipovi = assembly.GetTypes();
            List<string> tippp = new List<string>();
            List<string> tipp = new List<string>();
            foreach (var tip in tipovi)
            {
                tippp.Add(tip.ToString());
                foreach (var tipppp in tippp)
                {
                    tipp.Add(tipppp);
                }
            }

            return Ok(tippp);
        }

        /// <summary>
        /// Uzeti svojstva iz navedenih klasa.
        /// </summary>
        /// <returns></returns>
        [HttpGet("getpropertis")]
        public (List<string>, List<string>) GetProperties()
        {
            var typeA = typeof(ReflectionTestiranje.Models.Autor);
            var propA = typeA.GetProperties();

            var typeK = typeof(ReflectionTestiranje.Models.Knjiga);
            var propK = typeK.GetProperties();

            //Dictionary<string, string> a = new Dictionary<string, string>();
            List<string> propaA = new List<string>();
            List<string> propkK = new List<string>();

            foreach (var propa in propA)
            {
                propaA.Add(propa.ToString());
                
            }
            foreach (var propk in propK)
            {
                propkK.Add(propk.ToString());
                
            }

            return (propaA, propkK);

        }

        [HttpGet("getattributes")]
        public IActionResult GetAllHttpGet()
        {
            var type = Type.GetType("ReflectionTestiranje.Controllers.AutorController");
            MemberInfo[] atributi = type.GetMembers();
            
            //List<string> a = new List<string>();
            //foreach (var tipovi in typeGet)
            //{
            //    a.Add(tipovi);
            //}

            return Ok(atributi.ToList());
        }

        [HttpGet("noviprimjer")]
        public IActionResult NoviGetRfleksija()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes();
            Dictionary<string, string> tipovi = new Dictionary<string, string>();
            
            foreach (var type in types)
            {
                
                var props = type.GetProperties();
                
                foreach (var prop in props)
                {
                    tipovi.Add(type.ToString(), props.ToString());
                }
                
            }

            return Ok(tipovi);
        }
    }
}