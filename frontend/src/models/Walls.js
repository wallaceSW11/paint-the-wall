class Wall {
    constructor(obj) {
        obj = obj || {};

        this.height = obj.height;
        this.width = obj.width;
        this.doors = obj.doors;
        this.windows = obj.windows;
    }
}

export default class Walls {
    constructor(obj) {
        obj = obj || {};

        this.firstWall = new Wall(obj.firstWall);
        this.secondWall = new Wall(obj.firstWall);
        this.thirdWall = new Wall(obj.thirdWall);
        this.fourthWall = new Wall(obj.fourthWall);
    }
}
