export class Item {
    public id: number;
    public name: string;
    public price: number;
    public type: string;
    public rentalPrice: number;
    public description: string;
    public dimension: string;
    public supplier: string;
    public availableQuantity: number;
    public restockDate: Date;
    public restockQuantity: number;

    constructor(id: number,
        name: string,
        price: number,
        type: string,
        rentalPrice: number,
        description: string,
        dimension: string,
        supplier: string,
        availableQuantity: number,
        restockDate: Date,
        restockQuantity: number,
    ) {
        this.id = id;
        this.name = name;
        this.price = price;
        this.type = type;
        this.rentalPrice = rentalPrice;
        this.description = description;
        this.dimension = dimension;
        this.supplier = supplier;
        this.availableQuantity = availableQuantity;
        this.restockDate = restockDate;
        this.restockQuantity = restockQuantity;
    }
}