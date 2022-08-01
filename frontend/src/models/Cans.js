export default class Cans {
    constructor(obj) {
        obj = obj || {};

        this.totalSquareMeter = obj.totalSquareMeter;
        this.totalLiters = obj.totalLiters;
        this.cans = obj.cans;
    }
}
