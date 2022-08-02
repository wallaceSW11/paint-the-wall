import Can from "./Can";

export default class CansNeeded {
    constructor(obj) {
        obj = obj || {};

        this.totalSquareMeter = obj.totalSquareMeter;
        this.totalLiters = obj.totalLiters;
        this.cans =
            (Array.isArray(obj.cans) && obj.cans.map((c) => new Can(c))) || [];
    }
}
