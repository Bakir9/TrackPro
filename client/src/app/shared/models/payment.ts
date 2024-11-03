export interface IPayment {
    id: number
    userId: number
    amount: number
    paymentMethod: string
    month: string
    year: string
    purpose: string
    paymentDate: Date
  }
