import { usePasswordApi } from "./password/usePasswordApi";

export const useApi = () => {
    const passwordApi = usePasswordApi();

    return {
        passwordApi
    }
};