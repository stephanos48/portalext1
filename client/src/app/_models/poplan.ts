export interface PoPlan {
    poPlanId: number;
    poNumber: string;
    poLine: string;
    supplier: string;
    customerOrderNumber: string;
    soNumber: string;
    orderDateTime: Date;
    customerPn: string;
    extremePn: string;
    partDescription: string;
    orderQty: number;
    receivedQty: number;
    containerId: string;
    containerExt: string;
    freightForwarder: string;
    destination: string;
    ams: string;
    bol: string;
    pallet: string;
    invoice: string;
    arrivalWk: string;
    requestDateTime: Date;
    promiseDateTime: Date;
    shipDateTime: Date;
    etaDateTime: Date;
    receiptDateTime: Date;
    poOrderStatus: string;
    poSentDateTime: string;
    poSentBy: string;
    poConfirmedDateTime: string;
    poConfirmedBy: string;
    notes: string;

}