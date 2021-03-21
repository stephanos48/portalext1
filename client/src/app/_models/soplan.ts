export interface SoPlan {
    soPlanId: number;
    soNumber: string;
    soLine: string;
    customer: string;
    customerOrderNumber: string;
    customerOrderLine: string;
    invNumber: string;
    orderDateTime: Date;
    customerPn: string;
    extremePn: string;
    partDescription: string;
    workOrderNumber: number;
    orderQty: number;
    shipQty: number;
    requestedDateTime: Date;
    promiseDateTime: Date;
    shipDateTime: Date;
    soOrderStatus: string;
    hotShipment: string;
    carrier: string;
    trackingInfo: string;
    shipToAddress: string;
    notes: string;

}