export interface IActivity{
    id: number
    name: string
    createdBy:string
    users?: IActivityMembers[];
}

export interface IActivityMembers {
    id:number;
    firstName: string;
    lastName: string;
    gender: string;
    birthday: string;
}