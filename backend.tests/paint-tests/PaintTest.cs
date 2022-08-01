using Xunit;
using paint_the_wall.src.Controllers;
using paint_the_wall.src.Models;
using paint_the_wall.src.Views;
using Microsoft.AspNetCore.Mvc;
using System;


namespace paint_tests;

public class PaintTest
{

    [Fact]
    public void ShouldCalculateThirdtyTwoSquareMeter()
    {
        Wall wall1 = new Wall(200, 400, 0, 0);
        Wall wall2 = new Wall(200, 400, 0, 0);
        Wall wall3 = new Wall(200, 400, 0, 0);
        Wall wall4 = new Wall(200, 400, 0, 0);

        LivingRoom livingRoom = new LivingRoom(wall1, wall2, wall3, wall4);

        PaintController paintController = new PaintController();

        var result = paintController.Calculate(livingRoom);
        var model = (result as OkObjectResult).Value as ValidModelView;

        Assert.IsType<OkObjectResult>(result);
        Assert.Equal("32.00", model.TotalSquareMeter);
        Assert.Equal("6.400", model.TotalLiters);
        Assert.Equal(1, model.Cans[0].Quantity);
        Assert.Equal("3.6", model.Cans[0].Liters);
        Assert.Equal(1, model.Cans[1].Quantity);
        Assert.Equal("2.5", model.Cans[1].Liters);
    }

    [Fact]
    public void ShouldCalculateTwentyNineSquareMeter()
    {
        Wall wall1 = new Wall(200, 500, 1, 0);
        Wall wall2 = new Wall(200, 400, 1, 2);
        Wall wall3 = new Wall(200, 100, 0, 0);
        Wall wall4 = new Wall(200, 100, 0, 0);

        LivingRoom livingRoom = new LivingRoom(wall1, wall2, wall3, wall4);

        PaintController paintController = new PaintController();

        var result = paintController.Calculate(livingRoom);
        var model = (result as OkObjectResult).Value as ValidModelView;

        Assert.IsType<OkObjectResult>(result);
        Assert.Equal("29.84", model.TotalSquareMeter);
        Assert.Equal("5.968", model.TotalLiters);
        Assert.Equal(1, model.Cans[0].Quantity);
        Assert.Equal("3.6", model.Cans[0].Liters);
        Assert.Equal(1, model.Cans[1].Quantity);
        Assert.Equal("2.5", model.Cans[1].Liters);
    }

    [Fact]
    public void ShouldThrowBadRequestTotalSquareMeterOverFifty()
    {
        Wall wall1 = new Wall(2100, 500, 1, 0);
        Wall wall2 = new Wall(200, 400, 1, 2);
        Wall wall3 = new Wall(200, 100, 0, 0);
        Wall wall4 = new Wall(200, 100, 0, 0);

        LivingRoom livingRoom = new LivingRoom(wall1, wall2, wall3, wall4);

        PaintController paintController = new PaintController();

        var result = paintController.Calculate(livingRoom);
        var model = (result as BadRequestObjectResult).Value as InvalidModelView;

        Assert.IsType<BadRequestObjectResult>(result);
        Assert.Contains("O metro quadrado não pode ser maior", model.Occurrences[0]);
    }
}