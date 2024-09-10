﻿using System.Collections.Generic;
using Asp.Versioning;
using BookStore.Controllers.V2.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers.V2.Controllers;

/// <summary>
/// Represents a RESTful people service.
/// </summary>
[ApiController]
[ApiVersion( "2.0" )]
[Route( "api/v{version:apiVersion}/People" )]
[ControllerName("People")]
public class PeopleController : ControllerBase
{
    /// <summary>
    /// Gets all people.
    /// </summary>
    /// <returns>All available people.</returns>
    /// <response code="200">The successfully retrieved people.</response>
    [HttpGet]
    [Produces( "application/json" )]
    [ProducesResponseType( typeof( IEnumerable<Person> ), 200 )]
    public IActionResult Get()
    {
        var people = new[]
        {
            new Person()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@somewhere.com"
            },
            new Person()
            {
                Id = 2,
                FirstName = "Bob",
                LastName = "Smith",
                Email = "bob.smith@somewhere.com"
            },
            new Person()
            {
                Id = 3,
                FirstName = "Jane",
                LastName = "Doe",
                Email = "jane.doe@somewhere.com"
            }
        };

        return Ok( people );
    }

    /// <summary>
    /// Gets a single person.
    /// </summary>
    /// <param name="id">The requested person identifier.</param>
    /// <returns>The requested person.</returns>
    /// <response code="200">The person was successfully retrieved.</response>
    /// <response code="404">The person does not exist.</response>
    [HttpGet( "{id:int}" )]
    [Produces( "application/json" )]
    [ProducesResponseType( typeof( Person ), 200 )]
    [ProducesResponseType( 404 )]
    public IActionResult Get( int id ) =>
        Ok( new Person()
            {
                Id = id,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@somewhere.com"
            }
        );
}
