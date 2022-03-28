//let data: number | string  = 42;

//data = '42'


//type script uses duck typing to check props 
//we use intellicene interface

export interface Duck {
    name: string;
    numLegs: number;
    makeSound: (sound: string) => void;
}


const duck1: Duck = {
    name: 'Obi',
    numLegs: 2,
    makeSound : (sound: any) => console.log(sound)
}


const duck2: Duck = {
    name: 'Jordan',
    numLegs: 2,
    makeSound : (sound: any) => console.log(sound)
}

duck1.makeSound('quack');


export const ducks = [duck1, duck2]