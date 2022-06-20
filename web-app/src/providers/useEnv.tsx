export type Env = {
    apiUrl: string;
};

export const useEnv = (): Env => {
    return {
        apiUrl: process.env.REACT_APP_APIURL!
    };
};