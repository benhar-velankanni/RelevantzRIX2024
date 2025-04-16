export class Title {
    constructor(public btitle: string) {}

    getbName(): string { 
        return this.btitle;
    }
}

export class Author {
    constructor(public bauthor: string) {}

    getbAuthor(): string {
        return this.bauthor;
    }
}

export class Pages {
    constructor(public bpage: number) {}

    getbpage(): number {
        return this.bpage;
    }
}

export class bCheckbox {
    constructor(public bcheckbox: boolean) {}

    getbCheckbox(): boolean {
        return this.bcheckbox;
    }
}

export function bookFromInput(input: Title | Author | Pages | bCheckbox) {
    if (input instanceof Title) {
        console.log(`Title is: ${input.getbName()}`);
    } else if (input instanceof Author) {
        console.log(`Author is: ${input.getbAuthor()}`);
    } else if (input instanceof Pages) {
        console.log(`Pages is: ${input.getbpage()}`);
    } else if (input instanceof bCheckbox) {
        console.log(`Book Instock: ${input.getbCheckbox()}`);
    }
}
