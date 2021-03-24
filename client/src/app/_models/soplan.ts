export interface SoPlan {
    soPlanId: number;
    soNumber: string;
    customer: string;
    customerOrderNo: string;
    customerOrderLine: string;
    invNumber: string;
    orderDateTime: Date;
    customerPn: string;
    extremePn: string;
    partDescription: string;
    workOrderNo: number;
    orderQty: number;
    shipQty: number;
    requestedDateTime: Date;
    promiseDateTime: Date;
    shipDateTime: Date;
    shipPlanStatus: string;
    hotShipment: string;
    carrier: string;
    trackingInfo: string;
    shipToAddress: string;
    notes: string;

}