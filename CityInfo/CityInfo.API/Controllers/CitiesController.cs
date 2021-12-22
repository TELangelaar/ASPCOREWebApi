using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using AutoMapper;
using CityInfo.API.Models;
using CityInfo.API.Services;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : ControllerBase
    {
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;

        public CitiesController(ICityInfoRepository cityInfoRepository, IMapper mapper)
        {
            _cityInfoRepository = cityInfoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCities()
        {
            var cityEntities = _cityInfoRepository.GetCities();

            //var results = cityEntities.Select(city => 
            //                                      new CityWithoutPointsOfInterestDto
            //                                      {
            //                                          Id = city.Id, Name = city.Name, Description = city.Description
            //                                      }).ToList();

            return Ok(_mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(cityEntities));
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id, bool includePointsOfInterest = false)
        {
            var city = _cityInfoRepository.GetCity(id, includePointsOfInterest);

            if (city == null)
            {
                return NotFound();
            }

            if (includePointsOfInterest)
            {
                //var cityResult = new CityDto()
                //                 {
                //                     Id = city.Id,
                //                     Name = city.Name,
                //                     Description = city.Description
                //                 };

                //foreach (var poi in city.PointsOfInterest)
                //{
                //    cityResult.PointsOfInterest.Add(
                //        new PointOfInterestDto()
                //        {
                //            Id = poi.Id,
                //            Name = poi.Name,
                //            Description = poi.Description
                //        });
                //}

                return Ok(_mapper.Map<CityDto>(city));
            }

            //var cityWithoutPointsOfInterestResult = new CityWithoutPointsOfInterestDto()
            //                                        {
            //                                            Id = city.Id,
            //                                            Name = city.Name,
            //                                            Description = city.Description
            //                                        };

            return Ok(_mapper.Map<CityWithoutPointsOfInterestDto>(city));
        }
    }
}
