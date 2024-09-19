export interface IActivity{
    id: number;
    createdBy:string;
    name: string;
    users?: IActivityMembers[];
}

export interface IActivityMembers {
    id:number;
    firstName: string;
    lastName: string;
    gender: string;
    birthday: string;
}