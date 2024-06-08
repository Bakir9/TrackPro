import { IUser } from "./user";

export interface IMember {
    id: string;
    firstName: string;
    lastName: string;
    title: string;
    gender: string;
    birthday: string;
    adress: string;
    email: string;
    password: string;
    phone: string;
    country: string;
    nationality: string;
    marriageStatus: string;
    memberFrom: string;
    active: string;
    lastActive: string;
    userPayments: IMemberPayments[];
}

export interface IMemberPayments {
  id: number;
  userId: number;
  amount: number;
  paymentMethod: string;
  year: string;
  purpose: string;
  paymentDate: string;  
}
