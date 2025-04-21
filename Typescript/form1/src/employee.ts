export class manager{
    display():string{
        console.log("Manager");
        return "Manager";
    }
}
export class developer{
    display():string{
        console.log("Developer");
        return "Developer";
    }
}

export function checkrole(input: manager | developer):string{
    if(input instanceof manager){
        return input.display();
    }
    else{
        return input.display();
    }
}