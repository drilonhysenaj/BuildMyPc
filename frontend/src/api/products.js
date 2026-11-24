import { apiRequest } from "./client";

export const getProducts = () => apiRequest("/api/products");