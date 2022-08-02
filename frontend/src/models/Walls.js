import Wall from "./Wall.js";

export default class Walls {
    constructor(obj) {
        obj = obj || {};

        this.firstWall = new Wall(obj.firstWall);
        this.secondWall = new Wall(obj.firstWall);
        this.thirdWall = new Wall(obj.thirdWall);
        this.fourthWall = new Wall(obj.fourthWall);
    }
}
