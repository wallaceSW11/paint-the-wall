export default class Wall {
    constructor(obj) {
        obj = obj || {};

        this.height = obj.height;
        this.width = obj.width;
        this.doors = obj.doors;
        this.windows = obj.windows;
    }
}
