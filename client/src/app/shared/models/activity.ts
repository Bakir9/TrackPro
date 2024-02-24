export interface IActivity{
    id: number;
    name: string;
    children?: IActivityChildren[];
}

export interface IActivityChildren {
    id:number,
    name: string;
}