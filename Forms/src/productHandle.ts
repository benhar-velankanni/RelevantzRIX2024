export class PName {
    constructor(public pvalue: string) {}
 
    getpName(): string {
        return this.pvalue;
    }
}
 
export class PPrice {
    constructor(public pvalue: number) {}
 
    getpPrice(): number {
        return this.pvalue;
    }
}
 
export class PCheckbox {
    constructor(public pcheckbox: boolean) {}
 
    getpCheckbox(): boolean {
        return this.pcheckbox;
    }
}
export function poductFromInput(input: PName | PPrice| PCheckbox) {
    if (input instanceof PName) {
        console.log(`Name is: ${input.getpName()}`);
    } else if (input instanceof PPrice) {
        console.log(`Price is: ${input.getpPrice()}`);
    } else if (input instanceof PCheckbox) {
        console.log(`Product Instock: ${input.getpCheckbox()}`);
    }
}