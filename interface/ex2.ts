interface Animal{
    species: string;
}
interface Pet extends Animal{
    name: string;
    isFriendly: boolean;
}
const pet: Pet = {
    species: 'dog',
    name: 'Max',
    isFriendly: true,
};
console.log(pet);
