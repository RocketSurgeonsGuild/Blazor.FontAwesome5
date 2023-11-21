if (!process.env.NUKE_BUILD_ASSEMBLY) {
    throw new Error("Environment variable 'NUKE_BUILD_ASSEMBLY' is not set.");
}

module.exports = {
    '!(*verified|*received).cs': filenames => [`dotnet ${process.env.NUKE_BUILD_ASSEMBLY} lint --lint-files ${filenames.join(' ')}`],
    '*.{csproj,targets,props,xml}': filenames => [`prettier --write '${filenames.join(`' '`)}'`],
    '*.{js,ts,jsx,tsx,json,yml,yaml}': filenames => [`prettier --write '${filenames.join(`' '`)}'`],
};
